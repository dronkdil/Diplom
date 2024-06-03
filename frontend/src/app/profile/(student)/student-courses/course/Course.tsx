import BaseCourse, { BaseCourseProps } from "@/components/course/BaseCourse"
import { Routes } from "@/lib/routes.constants"
import styles from "./Course.module.scss"

export type CourseProps = Omit<BaseCourseProps, "href"> & {
    level: string
    progress: number
    id: number
}

const Course = ({level, progress, id, ...rest}: CourseProps) => {
  return (
    <BaseCourse href={Routes.Course(id)} {...rest}>
      <span className={styles.course__level}>{level}</span>
      <span className={styles.course__progress}>{progress}%</span>
    </BaseCourse>
  )
}

export default Course
