'use client'
import { Field, Label } from "@headlessui/react"
import { InputHTMLAttributes, createRef, useState } from "react"
import InputWrapper from "../wrapper/InputWrapper"
import styles from "./FileInput.module.scss"

export type FileInput = 
  Omit<InputHTMLAttributes<HTMLInputElement>, "type" | "onChange"> & 
  {
  icon: React.ReactElement
  wrapperClassName?: string
  onChange?: (fileNames: FileList | never[]) => void
  error?: ResponseError
}

const FileInput = ({wrapperClassName, icon, placeholder, onChange, error, ...props}: FileInput) => {
  const ref = createRef<HTMLInputElement>()
  const [fileCount, setFileCount] = useState(0)

  return (
    <InputWrapper wrapperClassName={`${styles['input-wrapper']} ${wrapperClassName}`} icon={icon} onFocus={() => ref.current?.click()} error={error}>
        <Field>
            <Label className={styles["input-label"]}>{fileCount === 0 ? placeholder : `(${fileCount}) файлів`}</Label>
            <input ref={ref} className={styles.input} type="file" {...props} onChange={(e) => {
              onChange && onChange(ref.current?.files ?? [])
              setFileCount(ref.current?.files?.length ?? 0)
            }} />
        </Field>
    </InputWrapper>
  )
}

export default FileInput
