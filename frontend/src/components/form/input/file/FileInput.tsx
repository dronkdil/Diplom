'use client'
import { ResponseError } from "@/api/response.type"
import { Field, Label } from "@headlessui/react"
import { InputHTMLAttributes, createRef, forwardRef, useState } from "react"
import { mergeRefs } from "react-merge-refs"
import InputWrapper from "../wrapper/InputWrapper"
import styles from "./FileInput.module.scss"

export type FileInput = 
  Omit<InputHTMLAttributes<HTMLInputElement>, "type"> & 
  {
    icon: React.ReactElement
    wrapperClassName?: string
    error?: ResponseError
  }

const FileInput = forwardRef(({wrapperClassName, icon, placeholder, error, onChange, ...props}: FileInput, foreignRef) => {
  const ref = createRef<HTMLInputElement>()
  const [fileCount, setFileCount] = useState(0)

  return (
    <InputWrapper wrapperClassName={`${styles['input-wrapper']} ${wrapperClassName}`} icon={icon} onFocus={() => ref.current?.click()} error={error}>
        <Field>
            <Label className={styles["input-label"]}>{fileCount === 0 ? placeholder : `(${fileCount}) файлів`}</Label>
            <input 
              ref={mergeRefs([ref, foreignRef])} 
              className={styles.input} 
              type="file" 
              onChange={(e) => {
                onChange && onChange(e)
                setFileCount(ref.current?.files?.length ?? 0)
              }}
              {...props}
            />
        </Field>
    </InputWrapper>
  )
})

export default FileInput
