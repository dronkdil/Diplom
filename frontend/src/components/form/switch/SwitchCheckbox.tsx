"use client"
import { Field, Label, Switch } from "@headlessui/react"
import { InputHTMLAttributes, forwardRef, useEffect, useState } from "react"
import styles from './SwitchCheckbox.module.scss'

type SwitchCheckboxProps = Omit<InputHTMLAttributes<HTMLInputElement>, "onChange" |  "defaultValue"> & {
  onChange?: (value: boolean) => void
  onLabel?: string
  offLabel?: string
  defaultValue?: boolean
}

const SwitchCheckbox = forwardRef<HTMLButtonElement, SwitchCheckboxProps>(({onChange, onLabel, offLabel, defaultValue}: SwitchCheckboxProps, ref) => {
  const [selected, setSelected] = useState(false)

  useEffect(() => {
    setSelected(defaultValue ?? false)
  }, [defaultValue])
  
  return (
    <Field className={styles.switch}>
      {offLabel && <Label className={`${styles.switch__label} ${!selected && styles["switch__label--selected"]}`}>{offLabel}</Label>}
      <Switch
        checked={selected}
        onChange={(o) => {
          setSelected(o)
          onChange && onChange(o)
        }}
        className={styles.switch__control}
        ref={ref}
      >
        <span
          aria-hidden="true"
          className={styles.switch__dot}
        />
      </Switch>
      {onLabel && <Label className={`${styles.switch__label} ${selected && styles["switch__label--selected"]}`}>{onLabel}</Label>}
    </Field>
  )
})

export default SwitchCheckbox
