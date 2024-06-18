"use client"
import { LessonService } from "@/api/materialsForStudy/lesson/lesson.service"
import { LessonForPageType } from "@/api/materialsForStudy/lesson/type/lesson-for-page.type"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { useParams } from "next/navigation"
import { useState } from "react"
import { useSelector } from "react-redux"
import YouTube from "react-youtube"
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

  const {mutateAsync: onView} = useTypedMutation({
    name: `on-view-${id}`,
    request: () => LessonService.onView({lessonId: Number(id)}),
    conditional: () => user.role == "Student",
    onSuccess: () => setIsViewed(true),
    onError: () => setIsViewed(false)
  })

  const [isViewed, setIsViewed] = useState(false)

  return (
    <div className={styles.page}>
      <div className={styles.page__content}>
        <div className={styles.page__video}>
            {data?.videoType == "YoutubeVideo" && <YouTube
            videoId={data?.youtubeVideoId}
            opts={{
                playerVars: {
                    autoplay: 0,
                },
            }}
            onStateChange={(event) => {
                const player = event.target
                const duration = player.playerInfo.duration
                const current = player.playerInfo.currentTime

                if (!isViewed && current > duration * 0.8) {
                  onView()
                  setIsViewed(true)
                }
              }}
            />}
        </div>
        
        {data?.videoType != "YoutubeVideo" && <div className="text-white/50 mb-2">Тимчасово відео з усіх джерел окрім youtube не підтримуються</div>}
        
        {data?.haveHomework && <Homework description={data?.homeworkDescription} />}
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
