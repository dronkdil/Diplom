import { GhostLink } from "@/components/links"

export type GhostLessonButtonProps = {
    title: string
    id: number
    isCurrentLesson?: boolean
}

const GhostLessonButton = ({title, id, isCurrentLesson}: GhostLessonButtonProps) => {
  return (
    <GhostLink href={""}>
        <span>{title}</span>
    </GhostLink>
  )
}

export default GhostLessonButton
