import { ModuleType } from "@/api/materialsForStudy/course/types/course-page-info.type"
import { ModuleService } from "@/api/materialsForStudy/modules/module.service"
import { CreateModuleType } from "@/api/materialsForStudy/modules/type/create-module.type"
import { AccentButton } from "@/components/buttons"
import { ListboxInput } from "@/components/form"
import { DefaultInput, FileInput } from "@/components/form/input"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { AlignLeftIcon, ComponentIcon, FileIcon, TypeIcon } from "lucide-react"
import { useParams } from "next/navigation"
import { useForm } from "react-hook-form"
import styles from "./AddForm.module.scss"

type AddFormProps = {
  modules: ModuleType[]
  addModule: (module: CreateModuleType) => void
}

const AddForm = ({modules, addModule}: AddFormProps) => {
  const {id} = useParams()

  const {register: registerModule, getValues: getModuleValues, reset: resetModuleForm} = useForm({
    defaultValues: {
      title: "",
      description: ""
    } as CreateModuleType
  })
  const {isPending: moduleCreating, mutateAsync: createModule, errors} = useTypedMutation({
    name: "create-module",
    request: () => ModuleService.create({ ...getModuleValues() as CreateModuleType, courseId: Number(id) }),
    onSuccess: () => {
      addModule({ ...getModuleValues() as CreateModuleType, courseId: Number(id) })
      resetModuleForm()
    }
  })

  return (
    <div className={styles.forms}>
      <div className={styles.form}>
          <h3>Додати модуль</h3>
          <DefaultInput icon={<TypeIcon />} placeholder="Назва" {...registerModule("title")} error={errors.title} />
          <DefaultInput icon={<AlignLeftIcon />} placeholder="Короткий опис" {...registerModule("description")} error={errors.description} />
          <AccentButton isLoading={moduleCreating} onClick={() => createModule()}>Додати</AccentButton>
      </div>
      <div className={styles.form}>
          <h3>Додати урок</h3>
          <DefaultInput icon={<TypeIcon />} placeholder="Назва" />
          <DefaultInput icon={<AlignLeftIcon />} placeholder="Короткий опис" />
          <FileInput icon={<FileIcon />} placeholder="Відео" accept="video/mp4,video/x-m4v,video/*" />
          <ListboxInput values={modules.map(o => o.title)} icon={<ComponentIcon />} placeholder="Модуль" />
          <AccentButton>Додати</AccentButton>
      </div>
    </div>
  )
}

export default AddForm
