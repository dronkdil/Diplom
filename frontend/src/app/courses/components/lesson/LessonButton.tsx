import { DefaultLink } from '@/components/links'
import { Routes } from '@/lib/routes.constants'
import { CheckIcon } from 'lucide-react'
import styles from "./LessonButton.module.scss"

export type LessonButtonProps = {
    title: string
    id: number
    isCompleted?: boolean
}

const LessonButton = ({title, id, isCompleted}: LessonButtonProps) => {
  return (
    <DefaultLink href={Routes.Lesson(id)} className={styles.lesson}>
        <span>{title}</span>
        {isCompleted && <CheckIcon className={styles.lesson__checkicon} />}
    </DefaultLink>
  )
}

export default LessonButton
