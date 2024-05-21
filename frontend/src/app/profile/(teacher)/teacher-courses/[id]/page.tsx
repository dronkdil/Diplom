"use client"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useEffect } from "react"
import LessonButton from "../components/lesson/LessonButton"
import Module from "../components/module/Module"

const TeacherCoursePage = () => {
    const {setProfileTitle} = useReduxActions()
    useEffect(() => { setProfileTitle("Курс: Python") }, [])

    return (
        <div>

            <Module title="Назва модуля">
                {Array.from(Array(5).keys()).map((_, i) => <LessonButton 
                    title={`Урок ${i+1}`}
                    id={i+1}
                />)}
            </Module>
            <Module title="Модуль 2">
                {Array.from(Array(5).keys()).map((_, i) => <LessonButton 
                    title={`Урок ${i+1}`}
                    id={i+1}
                />)}
            </Module>
            <Module title="Модуль 3">
                {Array.from(Array(5).keys()).map((_, i) => <LessonButton 
                    title={`Урок ${i+1}`}
                    id={i+1}
                />)}
            </Module>
        </div>
    )
}

export default TeacherCoursePage


