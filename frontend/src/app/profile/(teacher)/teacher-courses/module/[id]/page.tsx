"use client"
import Setting from "@/app/profile/components/setting/Setting"
import { DefaultInput } from "@/components/form/input"
import { useReduxActions } from "@/hooks/useReduxActions"
import { EditIcon } from "lucide-react"
import { useEffect } from "react"

const ModuleSettingsPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Модуль: Назва модуля") }, [])
  
  return (
    <>
        <Setting title={"Назва"} actualData={"Назва модуля"}>
            <DefaultInput icon={<EditIcon />} defaultValue={"Назва модуля"} />
        </Setting>
    </>
  )
}

export default ModuleSettingsPage
