"use client"
import { StudentService } from "@/api/users/student/student.service"
import { StudentCourseType } from "@/api/users/student/types/student-course.type"
import AccentLink from "@/components/links/accent/AccentLink"
import Skeleton from "@/components/skeleton/Skeleton"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { Routes } from "@/lib/routes.constants"
import CourseExampleImage from "@public/images/CourseExample.png"
import { useEffect } from "react"
import styles from "./MyCourses.module.scss"
import Course from "./course/Course"

const MyCoursesPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої курси") }, [])
  
  const {data: studentCourses, isPending, isFailedResponse} = useTypedQuery<StudentCourseType[]>({
    name: 'get-student-courses',
    request: () => StudentService.getCourses(),
    successConditional: (response) => response?.data.value.length != 0
  })

  return (
    <>
      <div className={styles.courses}>
        {isFailedResponse && <div className={styles.courses__empty}>
          <span className={styles.empty__message}>Ви не приєднались до курсів, зробіть це прямо зараз!</span>
          <AccentLink href={Routes.Courses} className={styles.empty__button}>До курсів</AccentLink>
        </div>}

        {isPending && <>
          <Skeleton className={styles.courses__skeleton}></Skeleton>
          <Skeleton className={styles.courses__skeleton}></Skeleton>
          <Skeleton className={styles.courses__skeleton}></Skeleton>
        </>}

        {studentCourses?.map(o => <Course 
          key={o.id}
          imageSrc={CourseExampleImage.src}
          title={o.title}
          level={"Початковий"} 
          id={o.id}
          progress={o.progress}
        />)}
      </div>
    </>
  )
}

export default MyCoursesPage
