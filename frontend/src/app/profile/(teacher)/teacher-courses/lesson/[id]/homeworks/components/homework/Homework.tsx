"use client"
import { HomeworkService } from '@/api/materialsForStudy/homeworks/homework.service'
import { CompletedHomeworkType } from '@/api/materialsForStudy/homeworks/types/completed-homework.type'
import { EvaluateHomeworkType } from '@/api/materialsForStudy/homeworks/types/evaluate-homework.type'
import { AccentButton, DefaultButton } from '@/components/buttons'
import { ListboxInput } from '@/components/form'
import { DefaultInput } from '@/components/form/input'
import { useTypedMutation } from '@/hooks/useTypedMutation'
import { Disclosure, DisclosureButton, DisclosurePanel } from '@headlessui/react'
import { AlignLeftIcon, CandlestickChartIcon } from 'lucide-react'
import { useController, useForm } from 'react-hook-form'
import styles from "./Homework.module.scss"

export type HomeworkProps = CompletedHomeworkType & {
    onEvaluated: () => void
}

const Homework = ({id, studentDisplayName, answer, onEvaluated}: HomeworkProps) => {
    const {mutateAsync, isPending} = useTypedMutation({
        name: `evaluate-student-${id}`,
        request: () => HomeworkService.evaluate({
            id,
            ...getValues()
        } as EvaluateHomeworkType),
        onSuccess: () => {
            onEvaluated()
        }
    })

    const {register, getValues, control} = useForm()
    const { field: answerField } = useController({ control, name: "appraisal" });

  return (
    <Disclosure as={"div"} className={styles.homework}>
        {({open}) =>  <>
            <div className={styles.homework__header}>
                <div className={styles.homework__student}>{studentDisplayName}</div>
                <DisclosureButton>
                    <DefaultButton>{open ? "Закрити" : "Оцінити"}</DefaultButton>
                </DisclosureButton>
            </div>
            <DisclosurePanel className={styles.homework__content}>
                <div>
                    {/* <h4 className={styles.homework__description}>Перевірте дз та поставте оцінку</h4> */}
                    <div>
                        <span className={styles.homework__answer}>Відповідь: </span>
                        <span>{answer}</span>
                    </div>
                </div>
                <div className={styles.homework__form}>
                    <ListboxInput 
                        values={[1, 2, 3, 4, 5].map(o => ({id: 0, text: o}))} icon={<CandlestickChartIcon />}
                        placeholder='Оцінка'
                        onChange={o => answerField.onChange(o.text)} />
                    <DefaultInput 
                        {...register("comment")} 
                        icon={<AlignLeftIcon />} 
                        placeholder='Коментар' />
                    <AccentButton isLoading={isPending} onClick={() => mutateAsync()}>Підтвердити</AccentButton>
                </div>
            </DisclosurePanel>
        </>}
    </Disclosure>
  )
}

export default Homework
