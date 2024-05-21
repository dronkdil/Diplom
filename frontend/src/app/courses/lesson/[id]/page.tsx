"use client"
import { AccentButton } from "@/components/buttons"
import { FileInput } from "@/components/form/input"
import { BookIcon } from "lucide-react"
import { useState } from "react"
import LessonButton from "../../components/lesson/LessonButton"
import styles from "./Lesson.module.scss"

const LessonPage = () => {
  const [uploadedFiles, setUploadedFiles] = useState<File[]>()

  return (
    <div className={styles.page}>
      <div className={styles.page__content}>
        <video className={styles.page__video} />
        <div className={styles.page__homework}>
            <div>
                <h4 className={styles.homework__title}>Домашня робота</h4>
                <p className={styles.homework__description}>Lorem Ipsum - это текст-рыба, часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века</p>
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
        </div>
      </div>
      <div className={styles.page__lessons}>
        <div className={styles.lessons__side}>
            <h3 className={styles.page__title}>Урок 1</h3>
            <p className={styles.page__description}>Lorem Ipsum - это текст-рыба, часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века.</p>
        </div>
        <div className={`${styles.lessons__side} ${styles['lessons__side--right']}`}>
            {Array.from(Array(5).keys()).map((_, i) => <LessonButton 
                key={i}
                title={`Урок ${i+1}`}
                id={i+1}
            />)}
        </div>
      </div>
    </div>
  )
}

export default LessonPage
