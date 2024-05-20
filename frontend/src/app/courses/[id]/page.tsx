"use client"
import { AccentButton, DefaultButton } from "@/components/buttons"
import { Disclosure, DisclosureButton, DisclosurePanel } from "@headlessui/react"
import CourseExampleImage from "@public/images/CourseExample.png"
import { CheckIcon } from "lucide-react"
import Image from "next/image"
import { useParams } from "next/navigation"
import LessonButton from "../components/lesson/LessonButton"
import styles from "./Course.module.scss"

const CoursePage = () => {
    const { id } = useParams()
    const course = {
        title: "Python",
        description: "Lorem Ipsum - это текст-рыба, часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной рыбой для текстов на латинице с начала XVI века."
    }

    return (
        <div className={styles.course}>
            <div className={styles.course__info}>
                <Image src={CourseExampleImage.src} alt={course.title} width={150} height={150} />
                <h3>{course.title}</h3>
                <p className={styles.course__description}>{course.description}</p>
            </div>
            <div className={styles.course__modules}>

                <div className={styles["course__modules-header"]}>
                    <span>Безкоштовний курс</span>
                    <AccentButton>Доєднатись до курсу</AccentButton>
                </div>

                <Disclosure as={"div"} className={styles.course__module}>
                    <DisclosureButton className={styles.module__button}>
                        <span>Модуль 1</span>
                        <span><CheckIcon /></span>
                    </DisclosureButton>
                    <DisclosurePanel className={styles.module__items}>
                        {Array.from(Array(5).keys()).map((_, i) => <LessonButton 
                            title={`Урок ${i+1}`}
                            id={i+1}
                            isCompleted
                        />)}
                    </DisclosurePanel>
                </Disclosure>

                <Disclosure as={"div"} className={styles.course__module}>
                    <DisclosureButton className={styles.module__button}>
                        <span className={styles.module__title}>Модуль 1</span>
                        <span className={styles.module__progress}>1/3</span>
                    </DisclosureButton>
                    <DisclosurePanel className={styles.module__items}>
                        <DefaultButton className={styles.lesson}>
                            <span>Урок 1</span>
                            <CheckIcon className={styles.lesson__checkicon} />
                        </DefaultButton>
                        <DefaultButton>Урок 1</DefaultButton>
                        <DefaultButton>Урок 1</DefaultButton>
                    </DisclosurePanel>
                </Disclosure>

                <Disclosure as={"div"} className={styles.course__module}>
                    <DisclosureButton className={styles.module__button}>Модуль 2</DisclosureButton>
                    <DisclosurePanel className={styles.module__items}>
                        <DefaultButton>Урок 1</DefaultButton>
                        <DefaultButton>Урок 1</DefaultButton>
                        <DefaultButton>Урок 1</DefaultButton>
                    </DisclosurePanel>
                </Disclosure>
            </div>
        </div>
    )
}

export default CoursePage
