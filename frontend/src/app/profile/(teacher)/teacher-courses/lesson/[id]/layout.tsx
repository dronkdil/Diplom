"use client"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useEffect } from "react"

export type LessonLayoutProps = {
    children: any
}

const LessonLayout = ({children}: LessonLayoutProps) => {
    const {setProfileTitle} = useReduxActions()
    useEffect(() => { setProfileTitle("Урок: Урок 1") }, [])
        
    return (
        <>
            {children}
        </>
    )
}

export default LessonLayout
