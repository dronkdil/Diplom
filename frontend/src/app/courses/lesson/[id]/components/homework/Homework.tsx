import { HomeworkService } from "@/api/materialsForStudy/homeworks/homework.service"
import { CancelHomeworkType } from "@/api/materialsForStudy/homeworks/types/cancel-homework.type"
import { SendHomeworkType } from "@/api/materialsForStudy/homeworks/types/send-homework.type"
import { StudentHomeworkType } from "@/api/materialsForStudy/homeworks/types/student-homework.type"
import { AccentButton, DefaultButton } from "@/components/buttons"
import { DefaultInput } from "@/components/form/input"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { TextIcon } from "lucide-react"
import { useParams } from "next/dist/client/components/navigation"
import { useEffect } from "react"
import { useForm } from "react-hook-form"
import { useSelector } from "react-redux"
import styles from "./Homework.module.scss"

export type HomeworkProps = {
    description: string
}

const Homework = ({description}: HomeworkProps) => {
    const {id} = useParams()
    const user = useSelector(getUserData)
    
    const {data: homework, refetch: refetchHomework} = useTypedQuery<StudentHomeworkType>({
        name: `get-student-homework-${id}`,
        request: () => HomeworkService.getByStudent(user.id),
        conditional: () => user.role == "Student"
    })
    
    const {mutateAsync: sendHomework, isPending: homeworkSending} = useTypedMutation({
        name: `send-student-homework-${id}`,
        request: () => HomeworkService.send({
          id: homework?.id, 
          lessonId: Number(id), 
          studentId: user.id, 
          ...getHomeworkValues()
        } as SendHomeworkType),
        conditional: () => user?.role == "Student",
        onSuccess: () => {
          refetchHomework()
        }
    })

    const {mutateAsync: cancelHomework, isPending: homeworkCanceling} = useTypedMutation({
        name: `cancel-student-homework-${id}`,
        request: () => HomeworkService.cancel({
          id: homework?.id
        } as CancelHomeworkType),
        conditional: () => user?.role == "Student",
        onSuccess: () => {
          refetchHomework()
        }
    })

    const {register: registerHomework, getValues: getHomeworkValues, setValue: setHomeworkValue} = useForm()

    useEffect(() => {
        setHomeworkValue("answer", homework?.answer)
    }, [homework])

  return (
    <div className={styles.homework}>
        <div>
            <h4 className={styles.homework__title}>Домашня робота</h4>
            <p className={styles.homework__description}>{description}</p>
        </div>
        <div className={styles.homework__form}>
            {homework?.сompleted
                ? <div className={styles.homework__completed}>
                    {homework.appraisal && <div>Оцінка: {homework.appraisal}</div>}
                    {homework.commentFromTeacher && <div>Від вчителя: {homework.commentFromTeacher}</div>}
                    <div>Відповідь: {homework.answer}</div>
                    <DefaultButton 
                        isLoading={homeworkCanceling} 
                        onClick={() => cancelHomework()} 
                        className={styles["homework__hand-in"]}
                    >Відмінити</DefaultButton>
                </div>
                : <>
                    <DefaultInput 
                        {...registerHomework("answer")} 
                        icon={<TextIcon />} 
                        placeholder="Відповідь" />
                    <AccentButton 
                        isLoading={homeworkSending} 
                        onClick={() => sendHomework()} 
                        className={styles["homework__hand-in"]}
                    >Здати</AccentButton>
                </>}
        </div>
    </div>
  )
}

export default Homework
