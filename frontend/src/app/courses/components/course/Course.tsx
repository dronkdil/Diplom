import BaseCourse, { BaseCourseProps } from "@/components/course/BaseCourse"
import { Routes } from "@/lib/routes.constants"
import styles from "./Course.module.scss"

export type CourseProps = Omit<BaseCourseProps, "children" | "href"> & {
    level: string
    id: number
}

const Course = ({level, id, ...rest}: CourseProps) => {
  return (
    <BaseCourse href={Routes.Course(id)} {...rest}>
      <span className={styles.level}>{level}</span>
    </BaseCourse>
  )
}

export default Course
