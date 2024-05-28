"use client"
import { CourseService } from "@/api/materialsForStudy/course/course.service"
import { ShortCourseType } from "@/api/materialsForStudy/course/types/short-course.type"
import Searchbar from "@/components/form/searchbar/Searchbar"
import Skeleton from "@/components/skeleton/Skeleton"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { getAuthenticated } from "@/lib/redux/slices/AuthenticationSlice"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import CourseExampleImage from "@public/images/CourseExample.png"
import { useSelector } from "react-redux"
import styles from "./Courses.module.scss"
import Course from "./components/course/Course"

const CoursesPage = () => {
  const user = useSelector(getUserData)
  const isAuthenticated = useSelector(getAuthenticated)
  const {data: courses, isPending, isFailedResponse} = useTypedQuery<ShortCourseType[]>({
    name: 'get-courses',
    request: () => CourseService.getAllCourses()
  })

  return (
    <div className={styles.courses}>
      <div className={styles.courses__header}>
        <h3 className={styles.courses__welcome}>{isAuthenticated ? `Вітаю ${user.firstName}!` : 'Вітаємо!'}</h3>
        <div className={styles.courses__searchbar}><Searchbar /></div>
      </div>

      <div className={styles.courses__row}>
        <div className={styles.row__header}>
            <h4 className={styles.row__title}>Усі курси</h4>
            {/* <Link className={styles.row__link} href="#">Більше</Link> */}
        </div>
        <div className={styles.row__content}>
          {isFailedResponse && <>
            <span className={styles["row__empty-message"]}>Наразі ще немає курсів, ми працюємо над цим!</span>
          </>}

          {isPending && <>
            <Skeleton className={styles.row__skeleton}></Skeleton>
            <Skeleton className={styles.row__skeleton}></Skeleton>
            <Skeleton className={styles.row__skeleton}></Skeleton>
          </>}

          {courses?.map((o, i) => <Course 
              key={i}
              imageSrc={CourseExampleImage.src}
              title={o.title}
              level={"Початковий"}
              id={o.id}
          />)}
        </div>
      </div>
    </div>
  )
}

export default CoursesPage
