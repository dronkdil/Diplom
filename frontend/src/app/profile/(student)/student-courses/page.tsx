"use client"
import CourseExampleImage from "@/../public/images/CourseExample.png"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useEffect } from "react"
import styles from "./MyCourses.module.scss"
import Course from "./course/Course"

const MyCoursesPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої курси") }, [])
  
  return (
    <>
      <div className={styles.courses}>
        <Course 
          imageSrc={CourseExampleImage.src}
          title="Python"
          level="Початковий"
          href="#"
        />
        <Course 
          imageSrc={CourseExampleImage.src}
          title="хмара обчислювальна техніка"
          level="Середній"
          href="#"
        />
        <Course 
          imageSrc={CourseExampleImage.src}
          title="Data Analytics with python"
          level="Початковий"
          href="#"
        />
        <Course 
          imageSrc={CourseExampleImage.src}
          title="Python"
          level="Початковий"
          href="#"
          progress={64}
        />
        <Course 
          imageSrc={CourseExampleImage.src}
          title="Python"
          level="Початковий"
          href="#"
        />
        <Course 
          imageSrc={CourseExampleImage.src}
          title="Python"
          level="Початковий"
          href="#"
        />
        <Course 
          imageSrc={CourseExampleImage.src}
          title="Python"
          level="Початковий"
          href="#"
        />
        <Course 
          imageSrc={CourseExampleImage.src}
          title="Python"
          level="Початковий"
          href="#"
        />
      </div>
    </>
  )
}

export default MyCoursesPage
