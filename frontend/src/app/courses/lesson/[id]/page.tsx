"use client"
import { LessonService } from "@/api/materialsForStudy/lesson/lesson.service"
import { LessonForPageType } from "@/api/materialsForStudy/lesson/type/lesson-for-page.type"
import { DefaultLink } from "@/components/links"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { useParams } from "next/navigation"
import { useSelector } from "react-redux"
import LessonButton from "../../components/lesson/LessonButton"
import styles from "./Lesson.module.scss"
import Homework from "./components/homework/Homework"

const LessonPage = () => {
  const {id} = useParams()
  const user = useSelector(getUserData)

  const {data} = useTypedQuery<LessonForPageType>({
    name: `get-lesson-for-page-${id}`,
    request: () => LessonService.getForPage(Number(id)),
  })

  return (
    <div className={styles.page}>
      <div className={styles.page__content}>
        <video src={data?.videoUrl} controls className={styles.page__video} />
        <div className={styles.page__undervideo}>
          <DefaultLink download={data?.title} href={data?.videoUrl ?? ''}>Завантажити відео</DefaultLink>
        </div>
        {data?.homeworkStatus && <Homework description={data?.homeworkDescription} />}
      </div>
      <div className={styles.page__lessons}>
        <div className={styles.lessons__side}>
            <h3 className={styles.page__title}>{data?.title}</h3>
            <p className={styles.page__description}>{data?.description}</p>
        </div>
        <div className={`${styles.lessons__side} ${styles['lessons__side--right']}`}>
            {data?.otherLessons.map((o, i) => <LessonButton 
                key={i}
                title={o.title}
                id={o.id}
            />)}
        </div>
      </div>
    </div>
  )
}

export default LessonPage
