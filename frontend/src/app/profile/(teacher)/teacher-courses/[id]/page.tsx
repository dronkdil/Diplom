"use client"
import { CourseService } from "@/api/materialsForStudy/course/course.service"
import { CourseTypeInfoType } from "@/api/materialsForStudy/course/types/course-page-info.type"
import { UpdateCourseDescriptionType } from "@/api/materialsForStudy/course/types/update-description.type"
import { UpdateCourseImageByUrlType } from "@/api/materialsForStudy/course/types/update-image-by-url.type"
import { UpdateCourseTitleType } from "@/api/materialsForStudy/course/types/update-title.type"
import { DefaultInput } from "@/components/form/input"
import { DefaultLink } from "@/components/links"
import Setting from "@/components/setting/Setting"
import Skeleton from "@/components/skeleton/Skeleton"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { Routes } from "@/lib/routes.constants"
import { ImageIcon, SquarePenIcon } from "lucide-react"
import { useParams } from "next/navigation"
import { useEffect } from "react"
import AddForm from "../components/add-form/AddForm"
import LessonButton from "../components/lesson/LessonButton"
import Module from "../components/module/Module"
import styles from "./TeacherCourse.module.scss"

const TeacherCoursePage = () => {
    const {id} = useParams()

    const {data: course, isPending, refetch, isFailedResponse, setData} = useTypedQuery<CourseTypeInfoType>({
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
        <>
            {course && <div className="flex gap-2">
                <DefaultLink className="" href={Routes.Course(course?.id)}>До курсу</ DefaultLink>
                <DefaultLink className="" href={Routes.Teacher.CourseStudents(course?.id)}>Студенти</ DefaultLink>
            </div>}
            <div className={styles.settings}>
                <Setting 
                    title={"Зображення"} 
                    actualData={course?.imageUrl} 
                    request={(values) => CourseService.updateImageByUrl({id: Number(id), ...values} as UpdateCourseImageByUrlType)}
                    onSuccess={(data) => setData({...course, ...data})}
                >
                    {(register) => <>
                        <DefaultInput icon={<ImageIcon />} defaultValue={course?.imageUrl} placeholder="Силка на зображення" {...register("imageUrl")} />
                    </>}
                </Setting>
                <Setting 
                    title={"Назва"} 
                    actualData={course?.title} 
                    request={(values) => CourseService.updateTitle({id: Number(id), ...values} as UpdateCourseTitleType)}
                    onSuccess={(data) => setData({...course, ...data})}
                >
                    {(register) => <>
                        <DefaultInput icon={<SquarePenIcon />} defaultValue={course?.title} placeholder="Назва" {...register("title")} />
                    </>}
                </Setting>
                <Setting 
                    title={"Опис"}
                    actualData={course?.description}
                    request={(values) => CourseService.updateDescription({id: Number(id), ...values} as UpdateCourseDescriptionType)}
                    onSuccess={(data) => setData({...course, ...data})}
                >
                    {(register) => <>
                        <DefaultInput icon={<SquarePenIcon />} defaultValue={course?.description} placeholder="Опис" {...register("description")} />
                    </>}
                </Setting>
            </div>
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
                    {o.lessons.map(o1 => <LessonButton id={o1.id} title={o1.title} onDeleted={() => refetch()}/>)}
                    {(!o.lessons || o.lessons.length == 0) && <span className="text-center text-white/50 -mt-2 mb-1">Немає уроків</span>}
                </Module>)}

                <AddForm modules={course?.modules ?? []} addModule={() => refetch()} addLesson={() => refetch()} />
            </div>
        </>        
    )
}

export default TeacherCoursePage


