import BaseCourse, { BaseCourseProps } from "@/components/course/BaseCourse"
import styles from "./Course.module.scss"

export type TeacherCourseProps = Omit<BaseCourseProps, "children"> & {
    studentsCount: number
}

const TeacherCourse = ({studentsCount, ...rest}: TeacherCourseProps) => {
  return (
    <BaseCourse {...rest}>
      <span className={styles.course__level}>Cтудентів: {studentsCount}</span>
    </BaseCourse>
  )
}

export default TeacherCourse
