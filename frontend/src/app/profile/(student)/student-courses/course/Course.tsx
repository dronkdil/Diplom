import BaseCourse, { BaseCourseProps } from "@/components/course/BaseCourse"
import styles from "./Course.module.scss"

export type CourseProps = BaseCourseProps & {
    level: string
    progress: number
}

const Course = ({level, progress, ...rest}: CourseProps) => {
  return (
    <BaseCourse {...rest}>
      <span className={styles.course__level}>{level}</span>
      <span className={styles.course__progress}>{progress}%</span>
    </BaseCourse>
  )
}

export default Course
