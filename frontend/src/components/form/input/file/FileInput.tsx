'use client'
import { Field, Label } from "@headlessui/react"
import { InputHTMLAttributes, createRef } from "react"
import InputWrapper from "../wrapper/InputWrapper"
import styles from "./FileInput.module.scss"

export type FileInput = 
  Omit<InputHTMLAttributes<HTMLInputElement>, "type" | "onChange"> & 
  {
  icon: React.ReactElement
  wrapperClassName?: string
  onChange?: (fileNames: FileList | never[]) => void
}

const FileInput = ({wrapperClassName, icon, placeholder, onChange,  ...props}: FileInput) => {
  const ref = createRef<HTMLInputElement>()

  return (
    <InputWrapper wrapperClassName={`${styles['input-wrapper']} ${wrapperClassName}`} icon={icon} onFocus={() => ref.current?.click()}>
        <Field>
            <Label className={styles["input-label"]}>{placeholder}</Label>
            <input ref={ref} className={styles.input} type="file" multiple {...props} onChange={(e) => onChange && onChange(ref.current?.files ?? [])} />
        </Field>
    </InputWrapper>
  )
}

export default FileInput
