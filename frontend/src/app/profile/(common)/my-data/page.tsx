"use client"
import { SettingsService } from "@/api/users/settings/settings.service"
import { UpdateAvatarByUrlType } from "@/api/users/settings/type/update-avatar-by-url.type"
import { UpdateNamesType } from "@/api/users/settings/type/update-names.type"
import { UpdatePasswordType } from "@/api/users/settings/type/update-password.type"
import Setting from "@/components/setting/Setting"
import { useReduxActions } from "@/hooks/useReduxActions"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { DefaultInput } from "@components/form/input"
import { ImageIcon, PenLineIcon } from "lucide-react"
import { useEffect } from "react"
import { useSelector } from "react-redux"

const MyDataPage = () => {
  const user = useSelector(getUserData)
  const {updateUserData} = useReduxActions()
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої дані") }, [])

  return (
    <>
      <Setting 
        title="Аватарка" 
        actualData={(!user.avatarUrl || user.avatarUrl == '') ? 'Немає' : user.avatarUrl} 
        request={(values) => SettingsService.updateAvatarByUrl(values as UpdateAvatarByUrlType)}
        onSuccess={(data) => updateUserData(data)}
      >
        {(register) => <>
          <DefaultInput icon={<ImageIcon />} defaultValue={user.avatarUrl} placeholder="Силка на зображення" {...register("avatarUrl")} />
        </>}
      </Setting>
      <Setting 
        title="Ім'я фамілія" 
        actualData={user.displayName} 
        request={(values) => SettingsService.updateNames(values as UpdateNamesType)}
        onSuccess={(data) => updateUserData(data)}
      >
        {(register) => <>
          <DefaultInput icon={<PenLineIcon />} defaultValue={user.firstName} {...register("firstName")} />
          <DefaultInput icon={<PenLineIcon />} defaultValue={user.lastName} {...register("lastName")} />
        </>}
      </Setting>
      <Setting 
        title="Пароль" 
        actualData="*******" 
        request={(values) => SettingsService.updatePassword(values as UpdatePasswordType)}
      >
        {(register) => <>
          <DefaultInput icon={<PenLineIcon />} placeholder="Новий пароль" {...register("password")} />
        </>}
      </Setting>
    </>
  )
}

export default MyDataPage
