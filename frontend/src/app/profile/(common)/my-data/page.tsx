"use client"
import { useReduxActions } from "@/hooks/useReduxActions"
import { DefaultInput } from "@components/form/input"
import Setting from "@profile-components/setting/Setting"
import { PenLineIcon } from "lucide-react"
import { useEffect } from "react"

const MyDataPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої дані") }, [])

  return (
    <>
      <Setting title="Логін" actualData="Denis">
        <DefaultInput icon={<PenLineIcon />} defaultValue={"Denis"} />
      </Setting>
      <Setting title="Пошта" actualData="destr20202@gmail.com">
        <DefaultInput icon={<PenLineIcon />} />
      </Setting>
      <Setting title="Контактна адреса" actualData="Відсутня">
        <DefaultInput icon={<PenLineIcon />} />
      </Setting>
    </>
  )
}

export default MyDataPage
