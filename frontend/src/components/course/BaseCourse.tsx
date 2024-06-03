import Link from "next/link"
import styles from "./BaseCourse.module.scss"

export type BaseCourseProps = {
    imageSrc: string
    title: string
    inDeveloping?: boolean
    children?: any
    href: string
}

const BaseCourse = ({imageSrc, title, href, inDeveloping, children}: BaseCourseProps) => {
  return (
    <Link href={href} className={`${styles.course} ${inDeveloping && styles["course--in-developing"]}`}>
        <div className={styles.course__image} style={{
          backgroundImage: `url(${imageSrc})`
        }} />
        <h4 className={styles.course__title}>{title}</h4>
        {children}
    </Link>
  )
}

export default BaseCourse
