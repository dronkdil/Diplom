"use client"
import { SwitchCheckbox } from "@/components/form"
import { DefaultInput } from "@/components/form/input"
import { useReduxActions } from "@/hooks/useReduxActions"
import Setting from "@profile-components/setting/Setting"
import { PenLineIcon } from "lucide-react"
import { useEffect } from "react"

const SettingsPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Налаштування") }, [])

  return (
    <>
      <Setting title="Сповіщення на почту" actualData="Вимкнено">
        <SwitchCheckbox offLabel="Викл." onLabel="Вкл." />
      </Setting>
      <Setting title="Мова та регіон" actualData="Українська">
        <DefaultInput icon={<PenLineIcon />} />
      </Setting>
      <Setting title="Налаштування конфіденційності" actualData="Відсутня">
        <DefaultInput icon={<PenLineIcon />} />
      </Setting>
    </>
  )
}

export default SettingsPage
