"use client"
import { CourseService } from "@/api/materialsForStudy/course/course.service"
import { CourseTypeInfoType } from "@/api/materialsForStudy/course/types/course-page-info.type"
import { CreateModuleType } from "@/api/materialsForStudy/modules/type/create-module.type"
import Skeleton from "@/components/skeleton/Skeleton"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { useParams } from "next/navigation"
import { useEffect, useState } from "react"
import AddForm from "../components/add-form/AddForm"
import Module from "../components/module/Module"
import styles from "./TeacherCourse.module.scss"

const TeacherCoursePage = () => {
    const {id} = useParams()
    const [addedModules, setAddedModules] = useState<CreateModuleType[]>([])

    const {data: coursePage, isPending, refetch} = useTypedQuery<CourseTypeInfoType>({
        name: `get-course-page-info-${id}`,
        request: () => CourseService.getCourse(Number(id))
    })

    if (coursePage && coursePage.data.type != "Successfully") {
        console.log(coursePage.data)
        return <span>Помилка</span>
    }

    const {setProfileTitle} = useReduxActions()
    useEffect(() => { setProfileTitle(`Курс: ${coursePage?.data.value.title ?? '...'}`) }, [coursePage])

    return (
        <div className={styles.modules}>
            {isPending && <>
                <Skeleton className={styles.modules__skeleton}></Skeleton>
                <Skeleton className={styles.modules__skeleton}></Skeleton>
                <Skeleton className={styles.modules__skeleton}></Skeleton>
            </>}

            {coursePage?.data.value.modules.map(o => <Module 
                description={o.description} 
                title={o.title} 
                id={o.id}
                onDeleted={() => refetch()}
            >
                <span className="text-center text-white/50 -mt-2 mb-1">Немає уроків</span>
            </Module>)}

            <AddForm modules={coursePage?.data.value.modules ?? []} addModule={o => refetch()} />
        </div>
    )
}

export default TeacherCoursePage


