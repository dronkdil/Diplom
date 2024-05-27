"use client"
import { TeacherService } from "@/api/users/teacher/teacher.service"
import { TeacherCourseType } from "@/api/users/teacher/types/teacher-course.type"
import Skeleton from "@/components/skeleton/Skeleton"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import CourseExampleImage from "@public/images/CourseExample.png"
import { useEffect } from "react"
import styles from "./MyCourses.module.scss"
import TeacherCourse from "./components/course/Course"

const TeacherCoursesPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої курси") }, [])

  const {data: courses, isPending} = useTypedQuery<TeacherCourseType[]>({
    name: 'get-teacher-courses',
    request: () => TeacherService.getCourses()
  })
  
  return (
    <>
      <div className={styles.courses}>
        {isPending 
          ? <>
              <Skeleton className={styles.courses__skeleton}></Skeleton>
              <Skeleton className={styles.courses__skeleton}></Skeleton>
              <Skeleton className={styles.courses__skeleton}></Skeleton>
            </>
          : courses 
            ? courses.data.value.map((o, i) => <TeacherCourse 
                key={i}
                imageSrc={CourseExampleImage.src}
                title={o.title}
                id={o.id}
                studentsCount={o.studentCount}
              />) 
            : <span>Ви ще не маєте курсів</span>}
      </div>
    </>
  )
}


export default TeacherCoursesPage
