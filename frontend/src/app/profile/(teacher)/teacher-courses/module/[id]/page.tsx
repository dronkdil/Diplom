"use client"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useEffect } from "react"

const ModuleSettingsPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Модуль: Назва модуля") }, [])
  
  return (
    <>
        {/* <Setting title={"Назва"} actualData={"Назва модуля"}>
            <DefaultInput icon={<EditIcon />} defaultValue={"Назва модуля"} />
        </Setting> */}
    </>
  )
}

export default ModuleSettingsPage
