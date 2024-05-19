import { Routes } from "@/lib/routes.constants"
import Image from "next/image"
import Link from "next/link"
import styles from "./Course.module.scss"

export type CourseProps = {
    imageSrc: string
    title: string
    level: string
    id: number
    inDeveloping?: boolean
}

const Course = ({imageSrc, title, level, id, inDeveloping}: CourseProps) => {
  return (
    <Link href={inDeveloping ? "" : Routes.Course(id)} className={`${styles.course} ${inDeveloping && styles["course--in-developing"]}`}>
        <Image src={imageSrc} alt={title} className={styles.course__image} width={90} height={90} />
        <h4 className={styles.course__title}>{title}</h4>
        <span className={styles.course__level}>{level}</span>
    </Link>
  )
}

export default Course
