import { ModuleType } from "@/api/materialsForStudy/course/types/course-page-info.type"
import { LessonService } from "@/api/materialsForStudy/lesson/lesson.service"
import { CreateLessonType } from "@/api/materialsForStudy/lesson/type/create-lesson.type"
import { ModuleService } from "@/api/materialsForStudy/modules/module.service"
import { CreateModuleType } from "@/api/materialsForStudy/modules/type/create-module.type"
import { AccentButton } from "@/components/buttons"
import { ListboxInput } from "@/components/form"
import { DefaultInput } from "@/components/form/input"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { AlignLeftIcon, ComponentIcon, FileIcon, TypeIcon } from "lucide-react"
import { useParams } from "next/navigation"
import { useController, useForm } from "react-hook-form"
import styles from "./AddForm.module.scss"

type AddFormProps = {
  modules: ModuleType[]
  addModule: (module: CreateModuleType) => void
  addLesson: (lesson: CreateLessonType) => void
}

const AddForm = ({modules, addModule, addLesson}: AddFormProps) => {
  const {id} = useParams()

  const {register: registerModule, getValues: getModuleValues, reset: resetModuleForm} = useForm({
    defaultValues: {
      title: "",
      description: ""
    } as CreateModuleType
  })
  const {isPending: moduleCreating, mutateAsync: createModule, errors: moduleErrors} = useTypedMutation({
    name: "create-module",
    request: () => ModuleService.create({ ...getModuleValues() as CreateModuleType, courseId: Number(id) }),
    onSuccess: () => {
      addModule({ ...getModuleValues() as CreateModuleType, courseId: Number(id) })
      resetModuleForm()
    }
  })

  const {register: registerLesson, getValues: getLessonValues, reset: resetLessonForm, control: lessonControl} = useForm({
    defaultValues: {
      title: "",
      description: "",
      youtubeLink: "",
      moduleId: -1
    } as CreateLessonType
  })
  const {isPending: lessonCreating, mutateAsync: createLesson, errors: lessonErrors} = useTypedMutation({
    name: "create-lesson",
    request: () => LessonService.create(getLessonValues() as CreateLessonType),
    onSuccess: () => {
      addLesson(getLessonValues() as CreateLessonType)
      resetLessonForm()
    }
  })

  const { field: moduleIdField } = useController({ control: lessonControl, name: "moduleId" })
  return (
    <div className={styles.forms}>
      <div className={styles.form}>
          <h3>Додати модуль</h3>
          <DefaultInput 
            icon={<TypeIcon />} 
            placeholder="Назва" 
            {...registerModule("title")} 
            error={moduleErrors.title} />
          <DefaultInput 
            icon={<AlignLeftIcon />} 
            placeholder="Короткий опис" 
            {...registerModule("description")} 
            error={moduleErrors.description} />
          <AccentButton isLoading={moduleCreating} onClick={() => createModule()}>Додати</AccentButton>
      </div>
      <div className={styles.form}>
          <h3>Додати урок</h3>
          <DefaultInput 
            icon={<TypeIcon />} 
            placeholder="Назва" 
            {...registerLesson("title")} 
            error={lessonErrors.title} />
          <DefaultInput 
            icon={<AlignLeftIcon />} 
            placeholder="Короткий опис" 
            {...registerLesson("description")} 
            error={lessonErrors.description} />
          <DefaultInput
            icon={<FileIcon />} 
            placeholder="Посилання на youtube відео"
            {...registerLesson("youtubeLink")}
            error={lessonErrors.youtubeLink} />
          <ListboxInput
            values={modules.map(o => ({id: o.id, text: o.title}))} 
            icon={<ComponentIcon />} 
            placeholder="Модуль" 
            onChange={o => moduleIdField.onChange(o.id)}
            valueId={moduleIdField.value} />
          <AccentButton isLoading={lessonCreating} onClick={() => createLesson()}>Додати</AccentButton>
      </div>
    </div>
  )
}

export default AddForm
