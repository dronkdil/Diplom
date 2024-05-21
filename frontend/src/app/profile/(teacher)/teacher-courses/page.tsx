"use client"
import CourseExampleImage from "@/../public/images/CourseExample.png"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useEffect } from "react"
import styles from "./MyCourses.module.scss"
import TeacherCourse from "./course/Course"

const TeacherCoursesPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої курси") }, [])
  
  return (
    <>
      <div className={styles.courses}>
        {Array.from(Array(13).keys()).map((_, i) => <TeacherCourse 
          key={i}
          imageSrc={CourseExampleImage.src}
          title="Python"
          id={i}
          studentsCount={50}
        />)}
      </div>
    </>
  )
}

export default TeacherCoursesPage
