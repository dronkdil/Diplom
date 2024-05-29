"use client"
import { LessonService } from "@/api/materialsForStudy/lesson/lesson.service"
import { LessonForPageType } from "@/api/materialsForStudy/lesson/type/lesson-for-page.type"
import { AccentButton } from "@/components/buttons"
import { FileInput } from "@/components/form/input"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { BookIcon } from "lucide-react"
import { useParams } from "next/navigation"
import { useState } from "react"
import LessonButton from "../../components/lesson/LessonButton"
import styles from "./Lesson.module.scss"

const LessonPage = () => {
  const [uploadedFiles, setUploadedFiles] = useState<File[]>()
  const {id} = useParams()

  const {data} = useTypedQuery<LessonForPageType>({
    name: `get-lesson-for-page-${id}`,
    request: () => LessonService.getForPage(Number(id)),
  })

  return (
    <div className={styles.page}>
      <div className={styles.page__content}>
        <video src={data?.videoUrl} controls className={styles.page__video} />
        {data?.homeworkStatus && <div className={styles.page__homework}>
            <div>
                <h4 className={styles.homework__title}>Домашня робота</h4>
                <p className={styles.homework__description}>{data?.homeworkDescription}</p>
            </div>
            <div className={styles.homework__form}>
                <FileInput 
                  wrapperClassName={styles.homework__input} 
                  icon={<BookIcon />} 
                  placeholder="Завантажити"
                  multiple
                  onChange={(files) => {
                    if (files) setUploadedFiles(Array.from(files))
                  }}
                />
                {uploadedFiles?.map(f => <div className={styles.homework__file}>{f.name}</div>)}
                <AccentButton className={styles["homework__hand-in"]}>Здати</AccentButton>
            </div>
        </div>}
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
