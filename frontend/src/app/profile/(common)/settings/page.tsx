"use client"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useEffect } from "react"

const SettingsPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Налаштування") }, [])

  return (
    <>
      {/* <Setting title="Сповіщення на почту" actualData="Вимкнено">
        <SwitchCheckbox offLabel="Викл." onLabel="Вкл." />
      </Setting>
      <Setting title="Мова та регіон" actualData="Українська">
        <DefaultInput icon={<PenLineIcon />} />
      </Setting>
      <Setting title="Налаштування конфіденційності" actualData="Відсутня">
        <DefaultInput icon={<PenLineIcon />} />
      </Setting> */}
    </>
  )
}

export default SettingsPage
