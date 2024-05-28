"use client"
import { SettingsService } from "@/api/users/settings/settings.service"
import { UpdateNamesType } from "@/api/users/settings/type/update-names.type"
import { UpdatePasswordType } from "@/api/users/settings/type/update-password.type"
import Setting from "@/components/setting/Setting"
import { useReduxActions } from "@/hooks/useReduxActions"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { DefaultInput } from "@components/form/input"
import { PenLineIcon } from "lucide-react"
import { useEffect } from "react"
import { useSelector } from "react-redux"

const MyDataPage = () => {
  const user = useSelector(getUserData)
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої дані") }, [])

  return (
    <>
      <Setting title="Ім'я фамілія" actualData={user.displayName} request={(values) => SettingsService.updateNames(values as UpdateNamesType)}>
        {(register) => <>
          <DefaultInput icon={<PenLineIcon />} defaultValue={user.firstName} {...register("firstName")} />
          <DefaultInput icon={<PenLineIcon />} defaultValue={user.lastName} {...register("lastName")} />
        </>}
      </Setting>
      <Setting title="Пароль" actualData="***" request={(values) => SettingsService.updatePassword(values as UpdatePasswordType)}>
        {(register) => <>
          <DefaultInput icon={<PenLineIcon />} placeholder="Новий пароль" {...register("password")} />
        </>}
      </Setting>
    </>
  )
}

export default MyDataPage
