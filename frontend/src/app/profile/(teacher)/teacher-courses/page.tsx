"use client"
import { TeacherService } from "@/api/users/teacher/teacher.service"
import { TeacherCourseType } from "@/api/users/teacher/types/teacher-course.type"
import Skeleton from "@/components/skeleton/Skeleton"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { useEffect } from "react"
import styles from "./MyCourses.module.scss"
import TeacherCourse from "./components/course/Course"

const TeacherCoursesPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої курси") }, [])

  const {data: courses, isPending, isFailedResponse} = useTypedQuery<TeacherCourseType[]>({
    name: 'get-teacher-courses',
    request: () => TeacherService.getCourses(),
    successConditional: (response) => response?.data.value?.length != 0
  })
  
  return (
    <>
      <div className={styles.courses}>

        {isPending && <>
          <Skeleton className={styles.courses__skeleton}></Skeleton>
          <Skeleton className={styles.courses__skeleton}></Skeleton>
          <Skeleton className={styles.courses__skeleton}></Skeleton>
        </>}

        {isFailedResponse && <>
          <span>Ви ще не маєте своїх курсів</span>
        </>}

        {courses?.map((o, i) => <TeacherCourse 
          key={i}
          imageSrc={o.imageUrl}
          title={o.title}
          id={o.id}
          studentsCount={o.studentCount}
        />)}
      </div>
    </>
  )
}


export default TeacherCoursesPage
