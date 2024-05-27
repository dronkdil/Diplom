"use client"
import { CourseService } from "@/api/materialsForStudy/course/course.service"
import { CourseTypeInfoType } from "@/api/materialsForStudy/course/types/course-page-info.type"
import Skeleton from "@/components/skeleton/Skeleton"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { Disclosure, DisclosureButton, DisclosurePanel } from "@headlessui/react"
import CourseExampleImage from "@public/images/CourseExample.png"
import Image from "next/image"
import { useParams } from "next/navigation"
import { useSelector } from "react-redux"
import styles from "./Course.module.scss"
import CourseHeader from "./components/header/CourseHeader"

const CoursePage = () => {
    const { id } = useParams()
    const user = useSelector(getUserData)

    const {data: coursePage, isPending: coursePagePending, refetch} = useTypedQuery<CourseTypeInfoType>({
        name: `get-course-page-info-${id}`,
        request: () => CourseService.getCourse(Number(id))
    })

    if (coursePage && coursePage.data.value == null) {
        return <span className={styles.error}>Помилка: такого курсу не існує</span>
    }

    return (
        <div className={styles.course}>
            <div className={styles.course__info}>
                {coursePagePending && <>
                    <Skeleton className="w-[150px] h-[150px]" />
                    <Skeleton className="w-[200px] h-[20px]" />
                    <Skeleton className="w-full max-w-[300px] h-[100px]" />
                </>}

                {coursePage?.data.value && <>
                    <Image src={CourseExampleImage.src} alt={coursePage?.data.value.title ?? ''} width={150} height={150} />
                    <h3>{coursePage?.data.value.title}</h3>
                    <p className={styles.course__description}>{coursePage?.data.value.description}</p>
                </>}
            </div>
            <div className={styles.course__modules}>

                <CourseHeader courseId={Number(id)} />

                {coursePagePending && <>
                    <Skeleton className={styles.modules__skeleton}></Skeleton>
                    <Skeleton className={styles.modules__skeleton}></Skeleton>
                    <Skeleton className={styles.modules__skeleton}></Skeleton>
                </>}

                {coursePage?.data.value?.modules.map((o, i) =>  <Disclosure 
                    as={"div"}
                    className={styles.course__module}
                    key={i}
                >
                    <DisclosureButton className={styles.module__button}>
                        <span>{o.title}</span>
                    </DisclosureButton>
                    <DisclosurePanel className={styles.module__content}>
                        <p className={styles.module__description}>{o.description}</p>
                        <div className={styles.module__lessons}>
                             {/* {o.lessons.map((o1, i) => <LessonButton 
                                title={`Урок ${i+1}`}
                                id={o1.title}
                                isCompleted={}
                            />)} */}
                        </div>
                        <span className={styles.module__empty}>Немає уроків</span>
                    </DisclosurePanel>
                </Disclosure>)}
            </div>
        </div>
    )
}

export default CoursePage
