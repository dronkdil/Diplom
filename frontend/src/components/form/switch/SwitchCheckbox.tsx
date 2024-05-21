"use client"
import { Field, Label, Switch } from "@headlessui/react"
import { InputHTMLAttributes, useState } from "react"
import styles from './SwitchCheckbox.module.scss'

interface SwitchCheckboxProps extends Omit<InputHTMLAttributes<HTMLInputElement>, "onChange"> {
  onChange?(checked: boolean): void
  onLabel?: string
  offLabel?: string
}

const SwitchCheckbox = ({checked, onChange, onLabel, offLabel}: SwitchCheckboxProps) => {
  const [selected, setSelected] = useState(false)
  
  return (
    <Field className={styles.switch}>
      {offLabel && <Label className={`${styles.switch__label} ${!selected && styles["switch__label--selected"]}`}>{offLabel}</Label>}
      <Switch
        checked={checked}
        onChange={(o) => {
          setSelected(o)
          onChange && onChange(o)
        }}
        className={styles.switch__control}
      >
        <span
          aria-hidden="true"
          className={styles.switch__dot}
        />
      </Switch>
      {onLabel && <Label className={`${styles.switch__label} ${selected && styles["switch__label--selected"]}`}>{onLabel}</Label>}
    </Field>
  )
}

export default SwitchCheckbox
