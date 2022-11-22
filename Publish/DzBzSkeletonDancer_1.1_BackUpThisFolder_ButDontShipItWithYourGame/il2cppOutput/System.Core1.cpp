#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};

// System.Type[]
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
// System.Reflection.Binder
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
// System.Reflection.MemberFilter
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
// System.String
struct String_t;
// System.Type
struct Type_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// System.Dynamic.Utils.TypeUtils/<>c
struct U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E;

IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E_il2cpp_TypeInfo_var;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct Il2CppArrayBounds;

// System.Reflection.MemberInfo
struct MemberInfo_t  : public RuntimeObject
{
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Dynamic.Utils.TypeUtils/<>c
struct U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E  : public RuntimeObject
{
};

struct U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E_StaticFields
{
	// System.Dynamic.Utils.TypeUtils/<>c System.Dynamic.Utils.TypeUtils/<>c::<>9
	U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E* ___U3CU3E9_0;
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// System.RuntimeTypeHandle
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	// System.IntPtr System.RuntimeTypeHandle::value
	intptr_t ___value_0;
};

// System.Type
struct Type_t  : public MemberInfo_t
{
	// System.RuntimeTypeHandle System.Type::_impl
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl_8;
};

struct Type_t_StaticFields
{
	// System.Reflection.Binder modreq(System.Runtime.CompilerServices.IsVolatile) System.Type::s_defaultBinder
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder_0;
	// System.Char System.Type::Delimiter
	Il2CppChar ___Delimiter_1;
	// System.Type[] System.Type::EmptyTypes
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes_2;
	// System.Object System.Type::Missing
	RuntimeObject* ___Missing_3;
	// System.Reflection.MemberFilter System.Type::FilterAttribute
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute_4;
	// System.Reflection.MemberFilter System.Type::FilterName
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName_5;
	// System.Reflection.MemberFilter System.Type::FilterNameIgnoreCase
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase_6;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void System.Dynamic.Utils.TypeUtils/<>c::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_m1D47C37129713530A6B1FE13BCB381295704FD22 (U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E* __this, const RuntimeMethod* method) ;
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void System.Dynamic.Utils.TypeUtils/<>c::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__cctor_m2FDD430879029E78453E21DB26F2A00DE0196692 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E* L_0 = (U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E*)il2cpp_codegen_object_new(U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		U3CU3Ec__ctor_m1D47C37129713530A6B1FE13BCB381295704FD22(L_0, NULL);
		((U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E_il2cpp_TypeInfo_var))->___U3CU3E9_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E_il2cpp_TypeInfo_var))->___U3CU3E9_0), (void*)L_0);
		return;
	}
}
// System.Void System.Dynamic.Utils.TypeUtils/<>c::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_m1D47C37129713530A6B1FE13BCB381295704FD22 (U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// System.Boolean System.Dynamic.Utils.TypeUtils/<>c::<.cctor>b__44_0(System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CU3Ec_U3C_cctorU3Eb__44_0_m2BD6021A86F56FAF62819F3E8E5C646C33189C84 (U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E* __this, Type_t* ___i0, const RuntimeMethod* method) 
{
	{
		Type_t* L_0 = ___i0;
		NullCheck(L_0);
		bool L_1;
		L_1 = VirtualFuncInvoker0< bool >::Invoke(39 /* System.Boolean System.Type::get_IsGenericType() */, L_0);
		return L_1;
	}
}
// System.Type System.Dynamic.Utils.TypeUtils/<>c::<.cctor>b__44_1(System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* U3CU3Ec_U3C_cctorU3Eb__44_1_mEC47DD3839EE48CD21585CB1ECD92E8D26693755 (U3CU3Ec_t5D488D45E7E9A7468509E0FA1FDFEE022913B16E* __this, Type_t* ___i0, const RuntimeMethod* method) 
{
	{
		Type_t* L_0 = ___i0;
		NullCheck(L_0);
		Type_t* L_1;
		L_1 = VirtualFuncInvoker0< Type_t* >::Invoke(47 /* System.Type System.Type::GetGenericTypeDefinition() */, L_0);
		return L_1;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
