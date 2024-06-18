"use client"
import { CourseService } from "@/api/materialsForStudy/course/course.service"
import { CourseTypeInfoType } from "@/api/materialsForStudy/course/types/course-page-info.type"
import { DefaultLink } from "@/components/links"
import Skeleton from "@/components/skeleton/Skeleton"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { getIsJoinedCourse } from "@/lib/redux/slices/IsJoinedCourseSlice"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { Disclosure, DisclosureButton, DisclosurePanel } from "@headlessui/react"
import { useParams } from "next/navigation"
import { useSelector } from "react-redux"
import LessonButton from "../components/lesson/LessonButton"
import styles from "./Course.module.scss"
import CourseHeader from "./components/header/CourseHeader"

const CoursePage = () => {
    const { id } = useParams()
    const user = useSelector(getUserData)
    const isJoinedCourse = useSelector(getIsJoinedCourse)

    const {data: course, isPending: coursePending, isFailedResponse} = useTypedQuery<CourseTypeInfoType>({
        name: `get-course-page-info-${id}`,
        request: () => CourseService.getCourse(Number(id))
    })

    const {data: averageScore, isPending: averageScorePending} = useTypedQuery<number>({
        name: `get-average-score-${id}`,
        request: () => CourseService.getAverageScore(Number(id)),
        conditional: () => isJoinedCourse && user.role == "Student"
    })

    if (isFailedResponse) {
        return <span className={styles.error}>Помилка: такого курсу не існує</span>
    }

    return (
        <div className={styles.course}>
            <div className={styles.course__info}>
                {coursePending && <>
                    <Skeleton className="w-[150px] h-[150px]" />
                    <Skeleton className="w-[200px] h-[20px]" />
                    <Skeleton className="w-full max-w-[270px] h-[100px]" />
                </>}

                {course && <>
                    <img src={course?.imageUrl} alt={course?.title ?? ''} className={styles.course__image} />
                    <h3 className={styles.course__title}>{course?.title}</h3>
                    <p className={styles.course__description}>{course?.description}</p>
                    {isJoinedCourse && !averageScorePending && <p className={styles.course__description}>Середній бал {averageScore}</p>}
                    <div className={styles.course__buttons}>
                        {course.chatLink && <DefaultLink target="_blank" href={course.chatLink}>Спільний чат курсу</DefaultLink>}
                        {course.scheduleLink && <DefaultLink target="_blank" href={course.scheduleLink}>Розклад семінарів</DefaultLink>}
                    </div>
                </>}
            </div>
            <div className={styles.course__modules}>

                <CourseHeader courseId={Number(id)} />

                {coursePending && <>
                    <Skeleton className={styles.modules__skeleton}></Skeleton>
                    <Skeleton className={styles.modules__skeleton}></Skeleton>
                    <Skeleton className={styles.modules__skeleton}></Skeleton>
                </>}

                {course?.modules.length == 0 && <>
                    <span className={styles.modules__empty}>Наразі модулі відсутні</span>
                </>}

                {course?.modules.map((o, i) =>  <Disclosure 
                    as={"div"}
                    className={styles.course__module}
                    key={i}
                >
                    <DisclosureButton className={styles.module__button}>
                        <span>{o.title}</span>
                        {o.completedLessons > 0 && <span>{o.completedLessons}/{o.lessons.length}</span>}
                    </DisclosureButton>
                    <DisclosurePanel className={styles.module__content}>
                        <p className={styles.module__description}>{o.description}</p>
                        <div className={styles.module__lessons}>
                            {o.lessons.map((o1, i) => <LessonButton 
                                key={i}
                                title={o1.title}
                                id={o1.id}
                                isCompleted={o1.completed}
                            />)}
                        </div>
                        {(!o.lessons || o.lessons.length == 0) && <span className={styles.module__empty}>Немає уроків</span>}
                    </DisclosurePanel>
                </Disclosure>)}
            </div>
        </div>
    )
}

export default CoursePage
