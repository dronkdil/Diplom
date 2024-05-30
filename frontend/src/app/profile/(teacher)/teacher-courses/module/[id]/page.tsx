"use client"
import { ModuleService } from "@/api/materialsForStudy/modules/module.service"
import { ActualModuleType } from "@/api/materialsForStudy/modules/type/actual-module.type"
import { UpdateModuleDescriptionType } from "@/api/materialsForStudy/modules/type/update-description.type"
import { UpdateModuleTitleType } from "@/api/materialsForStudy/modules/type/update-title.type"
import { DefaultInput } from "@/components/form/input"
import Setting from "@/components/setting/Setting"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { SquarePenIcon } from "lucide-react"
import { useParams } from "next/navigation"
import { useEffect } from "react"

const ModuleSettingsPage = () => {  
  const {id} = useParams()
  const {data, setData} = useTypedQuery<ActualModuleType>({
    name: `get-module-for-settings-${id}`,
    request: () => ModuleService.getModuleForSettings(Number(id))
  })

  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle(`Модуль: ${data?.title ?? "..."}`) }, [data])

  return (
    <>
      <Setting 
        title={"Назва"} 
        actualData={data?.title} 
        request={(values) => ModuleService.updateTitle({id: Number(id), ...values} as UpdateModuleTitleType)}
        onSuccess={(data) => setData(data)}
      >
        {(register) => <>
          <DefaultInput icon={<SquarePenIcon />} defaultValue={data?.title} placeholder="Назва" {...register("title")} />
        </>}
      </Setting>
      <Setting 
        title={"Опис"}
        actualData={data?.description}
        request={(values) => ModuleService.updateDescription({id: Number(id), ...values} as UpdateModuleDescriptionType)}
        onSuccess={(data) => setData(data)}
      >
        {(register) => <>
          <DefaultInput icon={<SquarePenIcon />} defaultValue={data?.description} placeholder="Опис" {...register("description")} />
        </>}
      </Setting>
    </>
  )
}

export default ModuleSettingsPage
