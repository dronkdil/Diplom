import { AccentButton } from "@/components/buttons"
import { ListboxInput } from "@/components/form"
import { DefaultInput, FileInput } from "@/components/form/input"
import { AlignLeftIcon, ComponentIcon, FileIcon, TypeIcon } from "lucide-react"
import styles from "./AddForm.module.scss"

const AddForm = () => {
  return (
    <div className={styles.forms}>
      <div className={styles.form}>
          <h3>Додати модуль</h3>
          <DefaultInput icon={<TypeIcon />} placeholder="Назва" />
          <AccentButton>Додати</AccentButton>
      </div>
      <div className={styles.form}>
          <h3>Додати урок</h3>
          <DefaultInput icon={<TypeIcon />} placeholder="Назва" />
          <DefaultInput icon={<AlignLeftIcon />} placeholder="Короткий опис" />
          <FileInput icon={<FileIcon />} placeholder="Відео" accept="video/mp4,video/x-m4v,video/*" />
          <ListboxInput values={["Назва модуля", "Модуль 2", "Модуль 3"]} icon={<ComponentIcon />} placeholder="Модуль" />
          <AccentButton>Додати</AccentButton>
      </div>
    </div>
  )
}

export default AddForm
