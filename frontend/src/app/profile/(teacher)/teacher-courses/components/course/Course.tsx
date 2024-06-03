import BaseCourse, { BaseCourseProps } from "@/components/course/BaseCourse"
import { Routes } from "@/lib/routes.constants"
import styles from "./Course.module.scss"

export type TeacherCourseProps = Omit<BaseCourseProps, "children" | "href"> & {
    studentsCount: number
    id: number
}

const TeacherCourse = ({studentsCount, id, ...rest}: TeacherCourseProps) => {
  return (
    <BaseCourse href={Routes.Teacher.Course(id)} {...rest}>
      <span className={styles.course__level}>Cтудентів: {studentsCount}</span>
    </BaseCourse>
  )
}

export default TeacherCourse
