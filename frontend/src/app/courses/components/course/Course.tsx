import BaseCourse, { BaseCourseProps } from "@/components/course/BaseCourse"
import styles from "./Course.module.scss"

export type CourseProps = Omit<BaseCourseProps, "children"> & {
    level: string
}

const Course = ({level, ...rest}: CourseProps) => {
  return (
    <BaseCourse {...rest}>
      <span className={styles.level}>{level}</span>
    </BaseCourse>
  )
}

export default Course
