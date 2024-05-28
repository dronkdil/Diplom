import { LessonService } from '@/api/materialsForStudy/lesson/lesson.service'
import { IconButton } from '@/components/buttons'
import { GhostLink } from '@/components/links'
import IconLink from '@/components/links/icon/IconLink'
import { useTypedMutation } from '@/hooks/useTypedMutation'
import { Routes } from '@/lib/routes.constants'
import { SettingsIcon, TrashIcon } from 'lucide-react'
import styles from "./LessonButton.module.scss"

export type LessonButtonProps = {
    title: string
    id: number
    onDeleted: (id: number) => void
}

const LessonButton = ({title, id, onDeleted}: LessonButtonProps) => {
  const {mutateAsync: deleteLesson, isPending} = useTypedMutation({
    name: `remove-lesson-${id}`,
    request: () => LessonService.remove(id),
    onSuccess: () => {
      onDeleted(id)
    }
  })

  return (
    <span className={styles.lesson}>
        <div className={styles.lesson__content}>
          <span>{title}</span>
          <IconLink href={Routes.Teacher.LessonSettings(id)} className={styles.lesson__settings}><SettingsIcon /></IconLink>
          <GhostLink href={Routes.Teacher.LessonHomeworks(id)} className={styles.lesson__homework}>Домашні завдання</GhostLink>
          <IconButton isLoading={isPending} onClick={() => deleteLesson()}><TrashIcon /></IconButton>
        </div>
    </span>
  )
}

export default LessonButton
