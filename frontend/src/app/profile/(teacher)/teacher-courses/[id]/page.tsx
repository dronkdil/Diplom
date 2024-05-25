"use client"
import { CourseService } from "@/api/materialsForStudy/course/course.service"
import { CourseTypeInfoType } from "@/api/materialsForStudy/course/types/course-page-info.type"
import { CreateModuleType } from "@/api/materialsForStudy/modules/type/create-module.type"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { useParams } from "next/navigation"
import { useEffect, useState } from "react"
import AddForm from "../components/add-form/AddForm"
import Module from "../components/module/Module"

const TeacherCoursePage = () => {
    const {id} = useParams()
    const [addedModules, setAddedModules] = useState<CreateModuleType[]>([])

    const {data: coursePage, refetch} = useTypedQuery<CourseTypeInfoType>({
        name: 'get-course-page-info',
        request: () => CourseService.getCourse(Number(id))
    })

    if (coursePage && coursePage.data.type != "Successfully") {
        console.log(coursePage.data)
        return <span>Помилка</span>
    }

    const {setProfileTitle} = useReduxActions()
    useEffect(() => { setProfileTitle(`Курс: ${coursePage?.data.value.title ?? '...'}`) }, [coursePage])

    return (
        <div>
            {coursePage?.data.value.modules.map(o => <Module description={o.description} title={o.title} id={o.id}>
                {/* {Array.from(Array(5).keys()).map((_, i) => <LessonButton 
                    title={`Урок ${i+1}`}
                    id={i+1}
                />)} */}
                <span className="text-white/50 -mt-2 mb-1">Немає уроків</span>
            </Module>)}

            <AddForm addModule={o => refetch()} />
        </div>
    )
}

export default TeacherCoursePage


