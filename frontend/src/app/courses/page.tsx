import Course from "@/components/course/Course"
import Searchbar from "@/components/searchbar/Searchbar"
import CourseExampleImage from "@public/images/CourseExample.png"
import Link from "next/link"
import styles from "./Courses.module.scss"

const CoursesPage = () => {
  return (
    <div className={styles.courses}>
      <div className={styles.courses__header}>
        <h3 className={styles.courses__welcome}>Вітаю Денис!</h3>
        <div className={styles.courses__searchbar}><Searchbar /></div>
      </div>
      
      <div className={styles.courses__row}>
        <div className={styles.row__header}>
            <h4 className={styles.row__title}>Рекомендовані</h4>
            <Link className={styles.row__link} href="#">Більше</Link>
            <span className={styles.row__description}>Рекомендовано на основі ваших вподобань та вибраних курсів</span>
        </div>
        <div className={styles.row__content}>
            {Array.from(Array(5).keys()).map(() => <Course 
                imageSrc={CourseExampleImage.src}
                title="Python"
                level="Початковий"
                href="#"
            />)}
        </div>
      </div>

      <div className={styles.courses__row}>
        <div className={styles.row__header}>
            <h4 className={styles.row__title}>Усі курси</h4>
            <Link className={styles.row__link} href="#">Більше</Link>
        </div>
        <div className={styles.row__content}>
            {Array.from(Array(5).keys()).map(() => <Course 
                imageSrc={CourseExampleImage.src}
                title="Python"
                level="Початковий"
                href="#"
            />)}
        </div>
      </div>

      <div className={styles.courses__row}>
        <div className={styles.row__header}>
            <h4 className={styles.row__title}>У розробці</h4>
            <Link className={styles.row__link} href="#">Більше</Link>
        </div>
        <div className={styles.row__content}>
            {Array.from(Array(5).keys()).map(() => <Course 
                imageSrc={CourseExampleImage.src}
                title="Python"
                level="Початковий"
                href="#"
                inDeveloping
            />)}
        </div>
      </div>
    </div>
  )
}

export default CoursesPage
