"use client"
import { CourseService } from "@/api/materialsForStudy/course/course.service"
import { CourseTypeInfoType } from "@/api/materialsForStudy/course/types/course-page-info.type"
import Skeleton from "@/components/skeleton/Skeleton"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { useParams } from "next/navigation"
import { useEffect } from "react"
import AddForm from "../components/add-form/AddForm"
import Module from "../components/module/Module"
import styles from "./TeacherCourse.module.scss"

const TeacherCoursePage = () => {
    const {id} = useParams()

    const {data: course, isPending, refetch, isFailedResponse} = useTypedQuery<CourseTypeInfoType>({
        name: `get-course-page-info-${id}`,
        request: () => CourseService.getCourse(Number(id)),
        successConditional: (response) => response?.data.value != null
    })
    
    const {setProfileTitle} = useReduxActions()
    useEffect(() => { setProfileTitle(`Курс: ${course?.title ?? '...'}`) }, [course])

    if (isFailedResponse) {
        return <span className={styles.error}>Помилка: такого курсу не існує</span>
    }

    return (
        <div className={styles.modules}>
            {isPending && <>
                <Skeleton className={styles.modules__skeleton}></Skeleton>
                <Skeleton className={styles.modules__skeleton}></Skeleton>
                <Skeleton className={styles.modules__skeleton}></Skeleton>
            </>}

            {course?.modules.map(o => <Module 
                description={o.description} 
                title={o.title} 
                id={o.id}
                onDeleted={() => refetch()}
            >
                <span className="text-center text-white/50 -mt-2 mb-1">Немає уроків</span>
            </Module>)}

            <AddForm modules={course?.modules ?? []} addModule={o => refetch()} />
        </div>
    )
}

export default TeacherCoursePage


