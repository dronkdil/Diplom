import { Routes } from "@/lib/routes.constants"
import Link from "next/link"
import styles from "./Course.module.scss"

export type TeacherCourseProps = {
    imageSrc: string
    title: string
    studentsCount: number
    id: number
}

const TeacherCourse = ({imageSrc, title, studentsCount, id}: TeacherCourseProps) => {
  return (
    <Link href={Routes.Profile.TeacherCourse(id)} className={`${styles.course}`}>
        <img src={imageSrc} alt={title} className={styles.course__image} />
        <h4 className={styles.course__title}>{title}</h4>
        <span className={styles.course__level}>Cтудентів: {studentsCount}</span>
    </Link>
  )
}

export default TeacherCourse
