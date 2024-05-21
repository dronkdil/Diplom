import { GhostLink } from '@/components/links'
import IconLink from '@/components/links/icon/IconLink'
import { Routes } from '@/lib/routes.constants'
import { SettingsIcon } from 'lucide-react'
import styles from "./LessonButton.module.scss"

export type LessonButtonProps = {
    title: string
    id: number
}

const LessonButton = ({title, id}: LessonButtonProps) => {
  return (
    <span className={styles.lesson}>
        <div className={styles.lesson__content}>
          <span>{title}</span>
          <IconLink href={Routes.Teacher.LessonSettings(id)}><SettingsIcon className={styles["lesson__settings-icon"]} /></IconLink>
          <GhostLink href={Routes.Teacher.LessonHomeworks(id)} className={styles.lesson__homework}>Домашні завдання</GhostLink>
        </div>
    </span>
  )
}

export default LessonButton
