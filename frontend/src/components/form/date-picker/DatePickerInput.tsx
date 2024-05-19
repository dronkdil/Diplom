import { InputMask } from '@react-input/mask'
import { HtmlHTMLAttributes, createRef } from 'react'
import { DefaultInputProps } from '../input/default/DefaultInput'
import InputWrapper from '../input/wrapper/InputWrapper'
import defaultStyles from "./../input/default/DefaultInput.module.scss"

export type DatePickerProps = HtmlHTMLAttributes<HTMLDivElement> & DefaultInputProps

const DatePicker = ({icon, wrapperClassName, ...props}: DatePickerProps) => {
    const ref = createRef<HTMLInputElement>()
    return (
        <InputWrapper icon={icon} onFocus={() => ref.current?.focus()}>
            <InputMask ref={ref} className={defaultStyles.default__input} {...props} mask="дд.мм.рррр" replacement={{ "д": /\d/, "м": /\d/, "р": /\d/ }} separate showMask={false}  />
        </InputWrapper>
    )
}

export default DatePicker