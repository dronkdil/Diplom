import { Routes } from "@/lib/routes.constants"
import Link from "next/link"
import styles from "./Course.module.scss"

export type CourseProps = {
    imageSrc: string
    title: string
    level: string
    id: number
    progress: number
}

const Course = ({imageSrc, title, level, id, progress}: CourseProps) => {
  return (
    <Link href={Routes.Course(id)} className={`${styles.course}`}>
        <img src={imageSrc} alt={title} className={styles.course__image} />
        <h4 className={styles.course__title}>{title}</h4>
        <span className={styles.course__level}>{level}</span>
        <span className={styles.course__progress}>{progress}%</span>
    </Link>
  )
}

export default Course
