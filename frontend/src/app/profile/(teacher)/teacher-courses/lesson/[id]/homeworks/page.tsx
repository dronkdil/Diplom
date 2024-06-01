"use client"
import { HomeworkService } from "@/api/materialsForStudy/homeworks/homework.service"
import { CompletedHomeworkType } from "@/api/materialsForStudy/homeworks/types/completed-homework.type"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { useParams } from "next/navigation"
import Homework from "./components/homework/Homework"

const LessonHomeworksPage = () => {
  const {id} = useParams()
  const {data, setData, isFailedResponse} = useTypedQuery<CompletedHomeworkType[]>({
    name: `completed-homeworks-${id}`,
    request: () => HomeworkService.getByLesson(Number(id)),
    successConditional: (response) => response?.data?.value.length != 0
  })

  return (
    <>
      {isFailedResponse && <span className="text-white/50">Наразі немає зданих домашніх завдань</span>}

      {data?.map((o, i) => <Homework 
        key={i} 
        {...o}
        onEvaluated={() => setData(o1 => o1?.filter(o2 => o2.id != o.id))} />)}
      {/* <GhostButton>Більше</GhostButton> */}
    </>
  )
}

export default LessonHomeworksPage
