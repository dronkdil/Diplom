import { Routes } from "@/lib/routes.constants"
import Link from "next/link"
import styles from "./BaseCourse.module.scss"

export type BaseCourseProps = {
    imageSrc: string
    title: string
    id: number
    inDeveloping?: boolean
    children?: any
}

const BaseCourse = ({imageSrc, title, id, inDeveloping, children}: BaseCourseProps) => {
  return (
    <Link href={inDeveloping ? "" : Routes.Course(id)} className={`${styles.course} ${inDeveloping && styles["course--in-developing"]}`}>
        <div className={styles.course__image} style={{
          backgroundImage: `url(${imageSrc})`
        }} />
        <h4 className={styles.course__title}>{title}</h4>
        {children}
    </Link>
  )
}

export default BaseCourse
