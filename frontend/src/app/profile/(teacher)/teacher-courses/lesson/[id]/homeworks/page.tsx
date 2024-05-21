import { GhostButton } from "@/components/buttons"
import Homework from "./components/homework/Homework"

const LessonHomeworksPage = () => {
  return (
    <>
        {Array.from(Array(3).keys()).map((_, i) => <Homework key={i} />)}
        <GhostButton>Більше</GhostButton>
    </>
  )
}

export default LessonHomeworksPage
