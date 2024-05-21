"use client"
import Setting from "@/app/profile/components/setting/Setting"
import { SwitchCheckbox } from "@/components/form"
import { DefaultInput } from "@/components/form/input"
import { SquarePenIcon } from "lucide-react"
import { useState } from "react"

const LessonPage = () => {
    const [haveHomework, setHaveHomework] = useState(false)

    return (
        <>
            <Setting title={"Назва"} actualData={"Урок 1"}>
                <DefaultInput icon={<SquarePenIcon />} defaultValue={"Урок 1"} />
            </Setting>
            <Setting title={"Опис"} actualData={"Пусто"}>
                <DefaultInput icon={<SquarePenIcon />} placeholder="Опис уроку" />
            </Setting>
            <Setting title={"Домашня робота"} actualData={"Присутня"}>
                <SwitchCheckbox onLabel="вкл." offLabel="викл." onChange={setHaveHomework} />
                {haveHomework && <DefaultInput icon={<SquarePenIcon />} placeholder="Опис домашньої роботи" />}
            </Setting>
        </>
    )
}

export default LessonPage
